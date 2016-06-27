Gauge example project, in C#
===========================

This project serves as an example for writing Automation using [Gauge](https://github.com/getgauge/gauge)

[![Build status](https://ci.appveyor.com/api/projects/status/6gyx0b3u6105xtic?svg=true)](https://ci.appveyor.com/project/sriv/gauge-example-csharp)
[![HTML report](https://img.shields.io/badge/report-html-green.svg)](https://ci.appveyor.com/project/sriv/gauge-example-csharp/build/artifacts)
[![Console report](https://img.shields.io/badge/report-console-blue.svg)](https://ci.appveyor.com/project/sriv/gauge-example-csharp)

# Concepts covered

- Use [Webdriver](http://docs.seleniumhq.org/projects/webdriver/) as base of implementation
- [Concepts](http://getgauge.io/documentation/user/current/gauge_terminologies/concepts.html)
- [Specification](http://getgauge.io/documentation/user/current/gauge_terminologies/specifications.html), [Scenario](http://getgauge.io/documentation/user/current/gauge_terminologies/scenarios.html) & [Step](http://getgauge.io/documentation/user/current/gauge_terminologies/steps.html) usage
- [Table driven execution](http://getgauge.io/documentation/user/current/advanced_readings/execution_types/table_driven_execution.html)
- [External datasource (special param)](http://getgauge.io/documentation/user/current/gauge_terminologies/parameters/special_parameters.html)


# Prerequisites
- [Install Gauge](http://getgauge.io/get-started/index.html)
- [Install Gauge-CSharp plugin](http://getgauge.io/documentation/user/current/installations/install_language_runners.html)
- .NET v4.5 (required for the CSharp plugin to run), you could write your test code to target a lesser version.
- Gauge Visual Studio plugin (optional, but recommended)
- [Java 1.7 or above](http://www.oracle.com/technetwork/java/javase/downloads/jdk8-downloads-2133151.html). [Required to bring up the [SUT](#setting-up-the-system-under-test-sut)]

# Setting up the System Under Test (SUT)

* Download [activeadmin-demo.war](https://bintray.com/artifact/download/gauge/activeadmin-demo/activeadmin-demo.war)
* Bring up the SUT by executing the below command
```
java -jar activeadmin-demo.war
```
* The SUT should now be available at [http://localhost:8080/](http://localhost:8080)


# Copyright
Copyright 2016, ThoughtWorks Inc.
