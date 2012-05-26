package controllers

import play.api.mvc._

object Appointments extends Controller {

  def index = Action {
    Ok(views.html.appointments.index());
  }

}