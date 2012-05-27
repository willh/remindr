package controllers

import play.api.mvc._

object Medications extends Controller {

  def index = Action { implicit request =>
    Ok(views.html.medications.index())
  }

  def reminder = TODO

}