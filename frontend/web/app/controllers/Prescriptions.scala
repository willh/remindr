package controllers

import play.api.mvc._

object Prescriptions extends Controller {

  def index = Action {
    Ok(views.html.prescriptions.index())
  }

  def reminder = TODO
  // call API to:
  //  create scheduled SMS to be sent on reminder date
  //  with body of reminder message as text
  //  to recipient of prescription mobile

}