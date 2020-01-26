# Airline Reservation - Assignment 1
Airline Reservation system for customer seating.
The airplane has 5 rows (1 to 5) with 4 seats (A to D).
Seats are in each row, 1A, 1B, 1C, 1D, 2A, 2B, etc.

## Functionalities
1. **Add customer to flight list**
    1. Request the customer name
    2. Display all seats when user selects "All Seats"
    3. Formating must be
    4. Seat - Customer Name
        1. Empty seats are: 1A -
        2. Assigned seats are: 2B - John Doe
2. **Seat Asssignment**
    1. Assign an available seat by selecting it using the row/seat list boxes and clicking “book”
    2. “Book” and “Add to waiting list” will add customer to the waiting list if there aren't more seats available
    3. “Status” will display seletect seat status:
        1. No customer
        2. Customer assigned
3. **Wait list**
    1. Wait list holds a maximum of 10 customers. 
    2. A full wait list will just show a message informing it.
    3. Cannot add customer to wait list with seats available
        1. Show the message “Seats are available”.
4. **Remove from the flight**
    1. Choose the row & seat to cancel
    2. Click “Cancel” to delete the passenger’s booking
    3. If the waiting list is not empty, remove the first person from the list and give her/him the newly vacated seat.
5. “Fill All” will fill all 20 seats. 

## Constraints
1. Seat Booking: 2D array
2. Wait list: single-dimensional array for the waiting list.
3. Business logic must be decoupled of the view
4. Loop to generate information when “show all” and “show waiting list”
    1. Display the information in the RichTextBoxes
    2. One line per seat.
5. Names can be a, but not empty.

## Validation Messages
1. “Book” is pressed but either the passenger name, row or seat is not selected.
2. “Book” is pressed when the chosen seat is already taken
3. “Add to Waiting List” is pressed when there are seats available.
4. “Cancel” is pressed without specifying the row/seat.
5. “Cancel” is pressed but the seat is not booked
6. After a successful booking, including one from the waiting list
7. After successfully cancelling a seat.
8. After successfully adding to the waiting list