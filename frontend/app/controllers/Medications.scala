package controllers

import play.api.mvc._
import play.api.data._
import play.api.data.Forms._
import play.api.i18n.Messages
import model.Medication

object Medications extends Controller {

  val medication = Form(
    mapping(
      "mobile" -> nonEmptyText,
      "reminderstart" -> date("dd-mm-yyyy"),
      "reminderend" -> date("dd-mm-yyyy"),
      "schedule" -> nonEmptyText,
      "message" -> nonEmptyText
    )(Medication.apply)(Medication.unapply)
  )

  def index = Action { implicit request =>
    Ok(views.html.medications.index())
  }

  def reminder = Action { implicit request =>
    medication.bindFromRequest.fold(
      errors => {
        Redirect(routes.Medications.index()).flashing(
          "error" -> Messages(errors.errors.head.message)
        )
      },
      meds => {
        sendScheduleRequest(meds)
        Redirect(routes.Medications.index()).flashing(
          "message" -> "Successfully scheduled medication reminder"
        )
      }
    )
  }

  def sendScheduleRequest(med: Medication) {
    // call API to:
    //  create scheduled SMS to be sent on daily or weekly basis
    //  from start date to end date
    //  with body of reminder message as text
    //  to recipient of mobile number
  }

}