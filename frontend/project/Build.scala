import sbt._
import Keys._
import PlayProject._

object ApplicationBuild extends Build {

  lazy val frontend = PlayProject("frontend", "0.1", dependencies, file("."), mainLang = SCALA).settings(
    resolvers += "webjars" at "http://webjars.github.com/m2"
  )

  lazy val dependencies = Seq("com.github.twitter" % "bootstrap" % "2.0.2")
}
