# projectWD

## TRACTIONAIR DESKTOP

###### Desktop application for viewing the database of ECU settings, customers and pressure groups.

The entry point of the application is the TractionAirForm.cs class, which shows the mainSettings table.
There are two main aspects to the app - the database, and interacting with the ECU through the USB port.
The database is altered through composing SQL commands based on user input into textboxes etc.
It is viewed through simple drag-and-drop dataGridView objects. The user can view other tables in the
database through the "Browse" menu strip item, which shows the Customers, Pressure Groups and Country
tables. The user can then add, change and delete entries from these as necessary.

One of the most important classes is the ECU_Manager.cs class, which contains many helper methods for
interacting with the database and to centralise many functions in different classes into one class.
This allows for greater code reuse and stops unncessary copy/pasting.

The SQL commands are composed using parameterisation to prevent the possibility of SQL Injection attacks.

The SerialManager.cs class is used for communication via USB.