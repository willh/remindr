package controllers

import play.api.mvc._

object Prescriptions extends Controller {

  def index = Action {
    Ok(views.html.prescriptions.index())
  }

  def reminder = TODO

}