# PlayStation VR Trophy Room

PlayStation VR Trophy Room is a VR application built in Unity that allows users to view their PlayStation trophy collection in a virtual, 3D environment.
Trophy Room utilizes the API provided by PlayStation and documented by [Andshrew](https://andshrew.github.io/PlayStation-Trophies/#/) to retrieve information about a user's trophy collection.
This program has been tested and is known to work well on a Meta Quest 2. 

## Goals
During the development of Trophy Room, I had some goals in mind that I wanted to achieve. These were: 

- I wanted to develop a prototype of what I felt an "official" VR trophy viewer could look like
- I wanted to gain experience using REST APIs in a Unity project 
- I wanted to begin development on a personal project that had plenty of room for growth and future development

## Future Features and directions 
- Implementing a system to allow other users to login with their PlayStation Network credentials to view their own trophy collections. (Currently using local
JSON files to glean trophy information)

- Overhauling the trophy interaction system to be more robust and easy to use

- I would also like to try an augmented reality version at some point in the future

## Known Bugs
-NullExceptionThrown when selecting Uncharted Legacy of Thieves Collection. This is because Uncharted has more trophies available than there are available 
spots on the "shelves." This will be fixed in a future update. 
