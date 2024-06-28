# My World - Magic Leap Project

## Introduction
This project, developed as a practical proposal for the Human-Computer Interaction course, focuses on an augmented reality (AR) survival game using the Magic Leap 1 device. Magic Leap combines real-world elements with virtual elements, allowing users to interact naturally and immersively. The goal is to create an entertaining, immersive experience that fully utilizes Magic Leap's mixed reality capabilities in both single-player and collaborative modes.

## Game Overview
My World is a survival game where the main character, controlled by the player, must fend off waves of enemies. The player uses the Magic Leap headset to visualize and control the character, who can perform predefined movements using the Magic Leap controller. The game features three rounds of increasing difficulty, where enemies spawn at the edge of the player's range. The game ends if the main character is hit by an enemy.

## Tools and Technologies
- **Unity 2020.2.2** and **SDK 0.25.0**: Main development environment.
- **Blender**: For 3D character modeling.
- **Mixamo**: For character animations.
- **Magic Leap Assets**: Utilized for camera access, environment mapping, and other mixed reality functionalities.

## Setup and Usage
To set up and run the project:
1. Clone the repository from [GitHub](https://github.com/Josep152/my_world_magicleap).
2. Open the project in Unity 2020.2.2.
3. Ensure the Magic Leap SDK 0.25.0 is installed.
4. Follow the instructions in the `Setup.md` file for device integration and initial configuration.
5. Use the Magic Leap controller to navigate and interact within the game.

## Game Modes
### Single Player
The player controls the main character, Hollow Knight, in a mapped virtual environment overlaying the real world. The game features three rounds of increasing enemy difficulty, with actions including movement, attack, and defense using the Magic Leap controller.

### Collaborative Mode
Developed using WebRTC for real-time collaboration, the game allows a second player to view the gameplay on a PC. A secondary controller generates 3D objects to obstruct enemy paths, enhancing collaborative gameplay.

## Challenges and Solutions
### Unity Compatibility
- Ensuring compatibility with Magic Leap required selecting the correct Unity version.
- Adaptations were made for efficient 3D model and texture handling to optimize performance on Magic Leap hardware.

### Real-time Environment Mapping
- Advanced algorithms were used for environment detection and mapping.
- Persistent and accurate integration of virtual objects with the real world was essential.

### Mixed Reality Interaction
- Natural and fluid interactions were prioritized, including gesture detection and controller use.
- High performance and low latency were critical to avoid motion sickness and ensure precise interactions.

## Future Work
- **Performance Optimization**: Further reduce latency and improve environment mapping.
- **Enhanced Multiplayer**: Implement full synchronization and data sharing for remote collaboration.
- **Extended Gameplay Features**: Introduce new enemy types, levels, and power-ups.

## Contribution Guidelines
We welcome contributions from the community. Please fork the repository and create a pull request with a detailed description of your changes. Ensure compatibility with the current project setup and adhere to the coding standards outlined in `CONTRIBUTING.md`.

## Visual Overview
![My World Game Overview](ImagesTest/game_screenshot.png)

For more details, refer to the complete project report and documentation in the repository.

## Contact
For any questions or further information, please reach out to the project maintainers via the GitHub repository.

