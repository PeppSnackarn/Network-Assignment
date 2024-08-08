# Network Assignment
 Network course assignment

 # Instructions
Objective: The goal of this assignment is to create a simple networked game using Unity's Netcode for GameObjects (NGO). The project will involve setting up a client-server architecture, implementing basic synchronization, and ensuring stable replication of game objects.

Requirements:

Game Design:

Create a simple multiplayer game. Suggestions include:

A basic top-down shooter.

A simple racing game.

A basic platformer.

The game should support at least two players (one host and one client).

Networked Game Features:

Implement a client-server model.

Ensure player movement is synchronized across the network.

Synchronize at least one other game object (e.g., projectiles, NPCs).

Implement in game communication (e.g., chat messages, emotes).

Implement server authority to handle game state and synchronization.

Steps:

Project Setup:

Create a new Unity project.

Add the Netcode for GameObjects package via the Package Manager.

Set up a basic scene with a player prefab and necessary game objects.

Network Manager:

Add a NetworkManager to your scene.

Configure the NetworkManager to handle player connections and object spawning.

Player Movement Synchronization:

Create a player prefab with a NetworkObject component.

Implement a basic movement script that uses Unity’s Input system.

Synchronize player movement across the network using NetworkTransform or a custom script.

Game Logic:

Add additional game logic such as shooting, scoring, or checkpoints.

Ensure all relevant actions are synchronized across the network.

Server Authority:

Implement server authority to manage game state.

Ensure all critical game logic (e.g., scoring, player death) is handled on the server.

Testing and Optimization:

Test the game with multiple players.

Optimize the network code to ensure smooth performance.

Handle common network issues such as latency and packet loss.

Documentation:

Document the development process.

Include explanations of how synchronization, server authority, and optimizations were implemented.