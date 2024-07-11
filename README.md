# Coding Test

## Objective

- Translate a problem into a working solution
- Demonstrate clear understanding of C# .NET.
- Communicate solution using clean code that is easy to read/understand
- Demonstrate ability to unit test code
- Provide clear instructions on how to verify solution

### Stretch goals

- Continuous integration of solution using Github actions
- Solution containerisation using Docker
- Code linting
- Code coverage reporting

## Get Started

Create a _public_ repository in [GitHub](https://github.com/) where the repository name is a [UUID](https://www.uuidgenerator.net/version4). Please keep committing to this GitHub repository as you develop your solution. Your solution is expected to be implemented in C# .NET. Please do not commit the company name in any of the documentation or code.

When you are done, share the repository URL with the person who asked you to try this exercise.

## Problem

Develop a function that takes one string input of any number of integers separated by single whitespace. The function then outputs the longest increasing subsequence (increased by any number) present in that sequence. If more than 1 sequence exists with the longest length, output the earliest one. You may develop supporting functions as many as you find reasonable. Your function should pass the test cases provided below.

## Solution
The requested logic is implemented as a static class located in test.Api project in a "Logic" folder in StringParserUtil.cs

Continuous integration is implemented using github actions and located in ./github/workflows/test-api.yml. Also, it is referenced as a solution item for a quick access.

Docker support is implementing by adding a dockerfile and specifying a custom port mapping to "5001" for https and "5000" for http.
Solution can be run in a docker mode by selecting "Container (Dockerfile)" from running options in visual studio or running manually docker commands: "docker build" and "docker run" frtom the root directory

Code linting is implemented a as a part of a building process using .editorconfig file and setting project property "EnforceCodeStyleInBuild" to true

Code coverage reporting is implemented using coverlet package and is available by running 
```text
dotnet test /p:CollectCoverage=true
```
from the root directory.
I tried to add code coverage to github actions as a badge but it was failing for some reason. Since it is not the main goal I skipped that part. Currently code coverage is available in a "Execute unit test" step as a console output.

To verify that solution is working run 
```text
dotnet tests
```
from the command line from the root directory and make sure that number of failed tests is 0.
Also, the logic is exposed from Api as a "[GET] parse" accepting a string with whitespace separated numbers and returning a string containing space separated numbers. To access logic from API run the solution in "https" mode and execute this curl:

```curl
curl -X 'GET' \
  'https://localhost:5501/parse?input=1%202%203' \
  -H 'accept: text/plain'
```

Swagger is also available for manual execution at a subroute "swagger"