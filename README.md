# Business Requirement
We have a cash register. It will use a printer to print purchase records.

## Question 1
We hope that CashRegister.Process() can use Printer.Print() to print Purchase. When the Process(...) method is called, the Print() method should also be called.

## Question 2
However, we don't want to use a real Printer for testing!

## Question 3
At the same time, we'd like to make sure that when Print() is triggered by Process(), the printed content is from the processed Purchase.

## Question 4
If the printer is out of paper, Process() should throw the specified exception.

## Question 5
Use Moq to eliminate all introduced classes just for tests.

# Practice Requirement
* Write the test code for the requirements as stated above ONE BY ONE.
* You can ONLY modify test code, except Question 1.
* Don't use any 3rd-party Mock library until except Question  5.
* Please git commit once after each question is completed (commit message example: `test(question1): add test for CashRegister.Process`)