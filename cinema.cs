Console.WriteLine("=== Movie Ticket System ===");

    
        Console.Write("Enter Movie Title: ");
        string movieTitle = Console.ReadLine();

        Console.Write("Number of Tickets: ");
        int numberOfTickets = int.Parse(Console.ReadLine());

        Console.Write("Price per Ticket: ");
        double pricePerTicket = double.Parse(Console.ReadLine());

        Console.Write("Duration of Movie (in hours): ");
        double durationHours = double.Parse(Console.ReadLine());

        Console.Write("Screen Number: ");
        int screenNumber = int.Parse(Console.ReadLine());

        Console.Write("First Letter of Seat Row: ");
        char seatRow = Console.ReadKey().KeyChar;
        Console.WriteLine(); 

        Console.Write("Is this a 3D Movie? (true/false): ");
        bool is3D = bool.Parse(Console.ReadLine());

        
        double totalTicketCost = numberOfTickets * pricePerTicket;
        double costPerHour = pricePerTicket / durationHours;

        
        Console.WriteLine("\n--- Summary ---");
        Console.WriteLine($"Movie: {movieTitle} {(is3D ? "(3D)" : "(2D)")}");
        Console.WriteLine($"Screen: {screenNumber} | Row: {seatRow}");
        Console.WriteLine($"Total Cost: ${totalTicketCost:F2}");
        Console.WriteLine($"Cost per Hour: ${costPerHour:F2}");