# LotteryDraws Application

**Setup:**
<p>
Project was created with Visual Studio 2019, with Angular and .Net Core compatability installed.
This should be able to be run directly from VS, launching the website and MVC/API backend at the same time without issue.
  </p>
  <p>
  Node will need to be installed, recommend version below to ensure compatability.
  <p/>
  <p>
  npm install may need to be run in the console, inside of the LotteryDraws\LotteryDraws\LotteryDraws\ClientApp directory
  </p>

__Installed Angular CLI version:__
<p>
CLI 9.0.1
Node 12.15.0
</p>
<strong>Improvements required:</strong>
<p>
The front-page should be styled more effectively, though Bootstrap makes it presentable at minimum for a prototype<br/>
Setup Teamcity/Octopus variables and transforms for different environments (ie TattsUrl -> Prod version where applicable)<br/>
Further error handling in backend/frontend for improved resiliency<br/>
Unit tests on Angular front-end to check appearances should be developed<br/>
Further unit testing on the backend services<br/>
Pagination for results, customisable number of results field (depending on requirement, may not want users to adjust)<br/>
Split into further projects, ie services addition, to contain helpers/service/ for more seperation (and add a data layer proj)
</p>
<strong>Notes:</strong>
<p>
The HTTP Helper method should be tested incidentally through use of the Tatts data service<br/>
Tests utilise NUnit<br/>
Dependancy injection is utilised for ease of use & development<br/>
Tested primarily on Firefox 80.0.1 (64-bit) (should adapt to mobile with bootstrap)
</p>
