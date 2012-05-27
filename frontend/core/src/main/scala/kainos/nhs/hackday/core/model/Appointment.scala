package kainos.nhs.hackday.core.model

import java.util.Date

case class Appointment(mobile: String, reminderDate: Date, oneWeekNotification: String, oneDayNotification: String, message: String)