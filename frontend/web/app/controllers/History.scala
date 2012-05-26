package controllers

import play.api.mvc._
import play.api.data._
import play.api.data.Forms._
import kainos.nhs.hackday.core.Api

object History extends Controller {

  val phone = Form(
    single("number" -> nonEmptyText)
  )

  def index = Action { implicit request =>
    Ok(views.html.history.index(Api.history))
  }

  def byNumber = Action { implicit request =>
    phone.bindFromRequest.fold(
      errors => Redirect(routes.History.index()).flashing(
        "error" -> "You must provide a number"
      ),
      number => Ok(views.html.history.index(Api.history(number)))
    )
  }

  def cancel(id: Int) = Action {
    Api.cancel(id)
    Redirect(routes.History.index()).flashing(
      "message" -> "Reminder cancelled"
    )
  }
}