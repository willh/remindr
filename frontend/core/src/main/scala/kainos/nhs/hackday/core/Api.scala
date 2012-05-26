package kainos.nhs.hackday.core

import kainos.nhs.hackday.model.{Kind, History}
import java.util.Date


object Api {

  var data = List(
    History(0, "Dr Foster", "02890 775317", Kind.Appointment, new Date),
    History(1, "Dr Foster", "02890 775317", Kind.Medication, new Date),
    History(2, "Dr Foster", "02890 775317", Kind.Prescription, new Date),
    History(3, "Dr Finnius", "02890 221619", Kind.Appointment, new Date),
    History(4, "Dr Newton", "02890 123456", Kind.Appointment, new Date)
  )

  def history : List[History] = data

  def history(number: String) : List[History] = data.filter(_.number.equals(number))

  def cancel(id: Int) {
    data = data.filterNot(_.id == id)
  }
}
