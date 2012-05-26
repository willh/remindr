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
      errors => Ok(views.html.history.index(Api.history)),
      number => Ok(views.html.history.index(Api.history(number)))
    )
  }

  def cancel(id: Int) = Action {
    Api.cancel(id)
    Redirect(routes.History.index()).flashing(
      "message" -> "Reminder cancelled"
    )
  }

  def view(id: Int) = Action {
    Api.get(id).map { item =>
      Ok(views.html.history.view(item))
    }.getOrElse {
      Redirect(routes.History.index()).flashing(
        "error" -> "Reminder does not exist"
      )
    }

  }
}