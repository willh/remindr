import sbt._
import Keys._
import PlayProject._

object ApplicationBuild extends Build {

  val root = Project("universe", file(".")).aggregate(frontend,common)

  lazy val common = Project("core", file("core"))
  lazy val frontend = PlayProject("frontend", "0.1", dependencies, file("web"), mainLang = SCALA).settings(
    resolvers += "webjars" at "http://webjars.github.com/m2"
  ).dependsOn(common)

  lazy val dependencies = Seq("com.github.twitter" % "bootstrap" % "2.0.2")
}
