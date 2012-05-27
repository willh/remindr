package controllers

import play.api.mvc._
import play.api.data._
import play.api.data.Forms._
import play.api.i18n.Messages
import model.Prescription
import play.api.libs.ws.WS
import api.Api

object Prescriptions extends Controller {

  val prescription = Form(
    mapping("mobile" -> nonEmptyText,
      "reminderdate" -> date("dd/MM/yyyy"),
      "message" -> nonEmptyText)(Prescription.apply)(Prescription.unapply)
  )

  def index = Action { implicit request =>
    Ok(views.html.prescriptions.index())
  }

  def reminder = Action { implicit request =>
    prescription.bindFromRequest.fold(
      errors => {
        Redirect(routes.Prescriptions.index()).flashing(
        "error" -> Messages(errors.errors.head.message)
        )
      },
      scrip => {
        Async{
          Api.prescriptionReminder(scrip).map { response =>
            println(response.body)
            Redirect(routes.Prescriptions.index()).flashing(
              "message" -> "Successfully scheduled prescription reminder"
            )
          }
        }
      }
    )
  }

}