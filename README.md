# Super Bowl Sorter!

Welcome to the Super Bowl Sorter! Here you can get access to some nicely sorted Super Bowl data, alongside sort future/past data too!

The main solution file is located in the "ProjectTwoUpdated" folder. The other folder "Project_Two (Deprecated)" is there to be documented in time, so please don't open that unless you want to see the development history.
The program will try to read and write into the ProjectTwoUpdated folder by default. You may specify your own path to the file if you wish.

## Usage
When you launch this program, it will ask you to verify the location of the CSV file. The provided CSV file is properly formatted, thus refer to it if you need a reference.
After verifying the file, it will ask you which file format you want. So far, it can only output either a text file or an HTML file.
Then, will ask you to designate the location of the output file and the name of it. If you're fine, you may accept these and continue.
The moment you accept the output location is the moment where the program outputs all of the requested queries to said location. From there, you can navigate the provided menus for the sake of convenience.


## Super Bowl Data Analytics Program (Project 2) Requirements

Your job for this project is to create an application that will quantify and summarize data from the excel sheet titled “Super_Bowl_Project.csv”.  Construct an application that will read data from the Super_Bowl_Project.csv spreadsheet and assign each of the row items as an object within your program.  Once your program has created an instance for each row within the spreadsheet begin to manipulate the data according to the bullet points below.  Once you have constructed code for the following bullet points generate a text file that outputs the quantified and summarized data.

### Generate a list of all super bowl winners and output the following:

1. The team name
2. The Year the team won
3. The winning quarterback
4. The winning coach
5. The MVP
6. The point difference between the winning pts and losing pts


### Generate a list of the top five attended super bowl’s and output the following:

1. The year
2. The winning team
3. The losing team
4. The city
5. The state
6. The stadium

### Output the state that hosted the  most super bowls and output the following:

1. The city
2. The state
3. The stadium

### Generate a list of players who won MVP more than once and output the following:

1. Name of MVP
2. The winning team
3. The losing team

### For the below questions, output the requested results

1. Which coach lost the most super bowls?
2. Which coach won the most super bowls?
3. Which team(s) won the most super bowls?
4. Which team(s) lost the most super bowls?
5. Which Super bowl had the greatest point difference?
6. What is the average attendance of all super bowls?

### Program Considerations

Please include a title for each output to the text file along with proper spacing

Allow the end-user to type in the desired path where file will write and read from.  If the file path does not exist, the program will end gracefully.

Your program should read the file from where the project folder exist.

## Requirements

Create using .NET Core Console Application

The Program should make use of Object Oriented Principles discussed in class and utilize at least one additional class structure beyond the class thats provided in the starter code.



## Additional Challenge 2-Points of Extra Credit
Instead of outputting to a text file generate a HTML document that displays the queried results.  The HTML document should also include CSS which provides the document with style.

This challenge will require a basic understanding of HTML and CSS.
