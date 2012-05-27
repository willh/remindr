package controllers

import play.api.mvc._
import play.api.data._
import play.api.data.Forms._

object Prescriptions extends Controller {

  val prescription = Form(
    tuple("mobile" -> nonEmptyText,
          "date" -> nonEmptyText,
          "reminder-message" -> nonEmptyText)
  )

  def index = Action {
    Ok(views.html.prescriptions.index())
  }

  def reminder = TODO
  // call API to:
  //  create scheduled SMS to be sent on reminder date
  //  with body of reminder message as text
  //  to recipient of prescription mobile

}