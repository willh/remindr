package kainos.nhs.hackday.core.model

import java.util.Date

case class Appointment(reminderDate: Date,message: String, mobile: String, oneWeekNotification: Boolean, oneDayNotification: Boolean)