If you want add a new template for the processing of excel-files then you must do next steps:
1. Inherit the new class from Accumulator Base and implement the method 'handle'.
2. Add the call of your class in  WorkerForm.cs (method button1_Click, the block 'switch')

For the work with excel-files was used the library https://code.google.com/p/excellibrary/
