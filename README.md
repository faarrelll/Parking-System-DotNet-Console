# Parking System CLI Application

A command-line interface application for managing a parking lot system, built with .NET Core. This application provides functionality for parking management with an enhanced user interface using Spectre.Console.

## Features

- Create parking lots with specified capacity
- Park vehicles with registration number, color, and type
- Remove vehicles from parking slots
- View current parking status
- Search vehicles by various criteria:
  - Vehicle type
  - Registration number (odd/even plates)
  - Color
  - Slot number

## Prerequisites

- .NET 6.0 or higher
- Visual Studio 2022 or VS Code with C# extension

## Installation

1. Clone the repository
```bash
git clone https://github.com/yourusername/ParkingSystem.git
```

2. Navigate to project directory
```bash
cd ParkingSystem
```

3. Install required packages
```bash
dotnet add package Spectre.Console
```

4. Build the project
```bash
dotnet build
```

5. Run the application
```bash
dotnet run
```

## Project Structure

```
ParkingSystem/
│
├── Program.cs
├── Constants/
│   └── CommandConstants.cs
├── Models/
│   └── Vehicle.cs
├── Interfaces/
│   └── IParkingLotService.cs
├── Services/
│   └── ParkingLotService.cs
├── Commands/
│   └── CommandHandler.cs
└── UI/
    ├── ConsoleUI.cs
    └── Helpers/
        └── TableHelper.cs
```

## Usage

Here are the available commands in the application:

1. Create a parking lot:
```bash
create_parking_lot 6
```

2. Park a vehicle:
```bash
park B-1234 White Car
```

3. Remove a vehicle from a slot:
```bash
leave 1
```

4. Display parking status:
```bash
status
```

5. Find vehicles by type:
```bash
type_of_vehicles Car
```

6. Find registration numbers for vehicles with odd/even plate numbers:
```bash
registration_numbers_for_vehicles_with_odd_plate
registration_numbers_for_vehicles_with_even_plate
```

7. Find registration numbers for vehicles with specific color:
```bash
registration_numbers_for_vehicles_with_color White
```

8. Find slot numbers for vehicles with specific color:
```bash
slot_numbers_for_vehicles_with_color White
```

9. Find slot number for specific registration number:
```bash
slot_number_for_registration_number B-1234
```

10. Exit the application:
```bash
exit
```

## Example Session

```bash
create_parking_lot 6
>> Created a parking lot with 6 slots

park B-1234 White Car
>> Allocated slot number: 1

park B-5678 Black Motorcycle 
>> Allocated slot number: 2

status
>> Slot No. Registration No Type Colour
>> 1       B-1234         Car  White  
>> 2       B-5678         Motorcycle Black

leave 2
>> Slot number 2 is free

type_of_vehicles Car
>> Number of vehicles of type Car: 1
```

## Contributing

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.

## Authors

* **Your Name** - *Initial work* - [YourGithubUsername](https://github.com/YourGithubUsername)

## Acknowledgments

* Spectre.Console for the enhanced CLI interface
* .NET Core team for the amazing framework