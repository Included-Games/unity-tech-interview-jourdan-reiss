The main goals of this technical test are to assess:
- whether you can write clean and maintainable code that is easy to understand, modify, and extend
- your communication skills
- your prioritisation skills

You are expected to implement the functionality that allows players to join the same game through a code. 

You should leverage the [Unity Lobby Service](https://docs.unity.com/lobby/en/manual/unity-lobby-service) APIs. The package has already been installed in the project. These APIs allow you to [create](https://docs.unity.com/lobby/en/manual/create-a-lobby) a lobby, [join](https://docs.unity.com/lobby/en/manual/join-a-lobby) an existing one, [poll for updates](https://docs.unity.com/lobby/en/manual/poll-for-updates), share custom [lobby](https://docs.unity.com/lobby/en/manual/update-lobby-data) and [player](https://docs.unity.com/lobby/en/manual/update-player-data) data, [heartbeat](https://docs.unity.com/lobby/en/manual/heartbeat-a-lobby) a lobby to avoid it being marked as inactive, [leave](https://docs.unity.com/lobby/en/manual/leave-a-lobby) a lobby or [delete](https://docs.unity.com/lobby/en/manual/delete-a-lobby) it. The lobby service requires that the player be authenticated before any API calls are made. You can assume that that's already been done somewhere else in the code base.

The screenshots below give you an idea of what the finished feature should look like. Due to the time constraint, you're not expected to finish the feature, but you're expected to prioritise the functionality that you think should be in the first build that the rest of the team can play test, which can then be iteratively improved upon. You're expected to write production quality code. This is not meant to be a prototype.

The project already contains a sample scene with some basic UI and a few interfaces that your implementation will need to rely on to start matchmaking, load each player's character, get a list of available dungeons, etc...

![Screenshot 2023-05-16 at 14 45 41](https://github.com/Included-Games/unity-tech-interview/assets/2270095/cd811368-e54c-4e85-acd4-431514edd44f)
![Screenshot 2023-05-16 at 14 46 01](https://github.com/Included-Games/unity-tech-interview/assets/2270095/2e1692ba-d77d-40dc-a848-eee583a7b543)
