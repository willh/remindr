package controllers

import play.api.mvc._
import play.api.data.Forms._
import play.api.data._
import model.Appointment
import api.Api
import play.api.i18n.Messages

object Appointments extends Controller {

  def index = Action { implicit request =>
    Ok(views.html.appointments.index())
  }

  val appointment = Form(
    mapping(
      "reminderDate"        -> date("dd/mm/yyyy"),
      "message"             -> nonEmptyText,
      "mobile"              -> nonEmptyText,
      "oneWeekNotification" -> boolean,
      "oneDayNotification"  -> boolean
    )(Appointment.apply)(Appointment.unapply)
  )

  def reminder = Action { implicit request =>
    appointment.bindFromRequest.fold(
      errors => {
        Redirect(routes.Appointments.index()).flashing(
          "error" -> Messages(errors.errors.head.message)
        )
      },
      appointment => {
        Async {
          Api.appointment(appointment).map { response =>
            Redirect(routes.Appointments.index()).flashing(
              "message" -> "Successfully scehuled an appointment reminder"
            )
          }
        }
      }
    )
  }

}