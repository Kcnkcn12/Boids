# Boids
# About The Project
This project is a personal project about Boids created to learn about emergent behavior, linear algebra, Unity, C#, and Github.

Boids follow a small set of rules that give rise to emergent behavior (in this case, flocking behavior) in a "procedural" manner. These rules are:
* **Separation**: Boids will move away from other boids (i.e. boids avoid running into each other).
* **Alignment**: Boids will move in the average direction and speed of other boids (i.e. boids move together)
* **Coherence**: Boids will move toward the average center position of the boids (i.e. boids group up)

Other non-essential rules include boid vision in which only boids that the boid can see are used in the calculations,
obstacle avoidance to avoid colliding with obstacles (i.e. separation but with other objects),
group designation (not used in project) in which only boids of a certain group will be considered in certain rules (e.g. same group: all rules, different group: only separation), etc.
# Installation/Download
You can either download the source files or directly access a playable build:
## Downloading Source Files
1. Clone the repo
```sh
git clone https://github.com/Kcnkcn12/Boids.git
```
2. Download Unity (This project is created using Unity Version 2019.4.16f1. While I highly doubt any issues will arise from using a different version, I cannot guarantee the project's stability.)

The general download page: https://store.unity.com/

The less convoluted download page assuming you want to download using the Unity Personal Plan: https://store.unity.com/download

3. Open up the project (the ./Boids folder) in Unity (if using Unity Hub, add it to the list of projects).
4. To create a playable build in Unity: "Files -> Build Settings" or "Files -> Build and Run".
## Downloading Playable Build
1. Clone the repo
```sh
git clone https://github.com/Kcnkcn12/Boids.git
```
or just the ./Boids/Builds folder (Note: I have no experience with this, so it may not work as intended).
```sh
git clone https://github.com/Kcnkcn12/Boids/tree/main/Boids/Builds
```
2. Run the ./Boids/Builds/Boids application.
# Usage
* WASD/Arrow Keys: Pan the camera
* Left Mouse Click: Spawn a Boid
* Right Mouse Click: Spawn an Obstacle
* Left Mouse Interact with UI: change boid interaction parameters
* Mouse Scroll Wheel: Zoom camera
* ESC Key: quit application
# Roadmap
Disclaimer: This is less of a roadmap and more of a list I would like to see done.
* Convert project to 3D
* Better UI (e.g. collapsable/Hidable UI, better contrast, list of controls)
* Improve play area (e.g. better scenery, handcrafted scene)
* Add new interactions/filters (e.g. boids are color-coded and perform Alignment and Cohesion with same-colored boids)
# Contributing
Disclaimer: I am not actively asking for contributions since I don't think this project is useful to anyone. However, if you want to contribute, I am happy to support.
1. Fork the Project
2. Create your Feature Branch (git checkout -b feature/AmazingFeature)
3. Commit your Changes (git commit -m 'Add some AmazingFeature')
4. Push to the Branch (git push origin feature/AmazingFeature)
5. Open a Pull Request
# Contact
kcnkcn12@gmail.com

Project Link: [https://github.com/Kcnkcn12/Boids](https://github.com/Kcnkcn12/Boids)
# Acknowledgements
## Inspiration
* [Sebastian Lague: "Coding Adventure: Boids" - YouTube](https://www.youtube.com/watch?v=bqtqltqcQhw)
* [dante: "How do Boids Work? A Flocking Simulation" - YouTube](https://www.youtube.com/watch?v=QbUPfMXXQIY)
* [Ben Eater: "Boids algorithm demonstration" - Website](https://eater.net/boids)
