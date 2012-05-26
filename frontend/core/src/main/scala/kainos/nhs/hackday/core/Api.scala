package kainos.nhs.hackday.core

import kainos.nhs.hackday.model.{Kind, History}
import java.util.Date


object Api {

  def history : List[History] = List(
    History("Dr Foster", "02890 775317", Kind.Appointment, new Date),
    History("Dr Foster", "02890 775317", Kind.Appointment, new Date),
    History("Dr Foster", "02890 775317", Kind.Appointment, new Date),
    History("Dr Foster", "02890 775317", Kind.Appointment, new Date),
    History("Dr Foster", "02890 775317", Kind.Appointment, new Date),
    History("Dr Foster", "02890 775317", Kind.Appointment, new Date),
    History("Dr Foster", "02890 775317", Kind.Appointment, new Date),
    History("Dr Foster", "02890 775317", Kind.Appointment, new Date),
    History("Dr Foster", "02890 775317", Kind.Appointment, new Date),
    History("Dr Foster", "02890 775317", Kind.Appointment, new Date),
    History("Dr Foster", "02890 775317", Kind.Appointment, new Date),
    History("Dr Foster", "02890 775317", Kind.Appointment, new Date),
    History("Dr Foster", "02890 775317", Kind.Appointment, new Date),
    History("Dr Foster", "02890 775317", Kind.Appointment, new Date),
    History("Dr Foster", "02890 775317", Kind.Appointment, new Date),
    History("Dr Foster", "02890 775317", Kind.Appointment, new Date)
  )

  def history(number: String) : List[History] = history.filter(_.number.equals(number))
}
