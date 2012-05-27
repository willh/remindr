package controllers

import play.api.mvc._
import play.api.data.Forms._
import play.api.data._
import model.Appointment
import api.Api

object Appointments extends Controller {

  def index = Action {
    Ok(views.html.appointments.index())
  }

  val appointment = Form(
    mapping(
      "reminderDate"        -> date("dd-mm-yyyy"),
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
          "error" -> "Could not bind form due to error"
        )
      },
      appointment => {
        Api.appointment(appointment)
        Redirect(routes.Appointments.index()).flashing(
          "message" -> "Successfully scehuled an appointment reminder"
        )
      }
    )
  }

}