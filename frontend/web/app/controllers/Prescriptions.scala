package controllers

import play.api.mvc._
import play.api.data._
import play.api.data.Forms._
import kainos.nhs.hackday.core.model._

object Prescriptions extends Controller {

  val prescription = Form(
    mapping("mobile" -> nonEmptyText,
      "reminderdate" -> date("dd-mm-yyyy"),
      "message" -> nonEmptyText)(Prescription.apply)(Prescription.unapply)
  )

  def index = Action { implicit request =>
    Ok(views.html.prescriptions.index())
  }

  def reminder = Action { implicit request =>
    prescription.bindFromRequest.fold(
      errors => {
        Redirect(routes.Prescriptions.index()).flashing(
        "error" -> "Could not bind form due to error"
        )
      },
      scrip => {
        sendScheduleRequest(scrip)
        Redirect(routes.Prescriptions.index()).flashing(
          "message" -> "Successfully scheduled prescription reminder"
        )
      }
    )
  }

  def sendScheduleRequest(ps: Prescription) {
    // call API to:
    //  create scheduled SMS to be sent on reminder date
    //  with body of reminder message as text
    //  to recipient of prescription mobile
  }

}