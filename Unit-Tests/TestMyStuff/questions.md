* What's a good unit-test?
  * It doesn't have coupling to dependencies of the subject under test
  * Has a known fixed input and known fixed output
  * Doesn't have conditions: ifs, switchs, or other types of conditions
  * Has a clear name: 
    * The must not lie!
    * The name must answer the following questions: 
      * What operation/behavior is under testing
      * What expectation/result is this test expecting
      * What conditions are in place on this test
    * Must be specific:
      * when the number 2 is the input use it in the name
      * when the number 5 is the output use it in the name
    * Has common structure between tests
      * Example: Arrange, Act, Assert
  * Doesn't hide exceptions
  * Small
  * Don't have locks or syncronization
  * Can run in parallel
  * Can run in any order
  * Doesn't share information with other tests
* What problem a unit-test solves?
  * Gives us garanties that our code works
  * Gives us garanties that our code keeps working
  * Clarifies what should be expected of our code
  * 
* How does it help me in day to day work?
  * Saves up time on debugging
  * Saves up time on buggy deploys
