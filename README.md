# What is this mod about?
This mod allows you to configure what locations do you not want to run in Hell Gate

# How to use?
1. Install the mod through the steam workshop
2. Open the game, go to "Mods" and enable this mod
3. Close the game
4. Go to the game user folder (on Windows it is `C:\Users\<User>\AppData\LocalLow\ATATGames\Ghostlore`)
5. You should see the file called `choose-hellgate-levels.config.json`, open it with any text editor
```json
{
  "LevelsToExclude": [],
  "AllHellgateLevels": [
    "Hijawan",
    "Intro Island",
    "Kubor",
    "Mangrove 2",
    "Quarry",
    "Temple"
  ]
}
```
6. The `AllHellgateLevels` array lists all hell gate level names. You should select those you don't want to use and put them into the `LevelsToExclude`

`Example: Exclude everything except intro island level`
```json
{
  "LevelsToExclude": [
    "Hijawan",
    "Kubor",
    "Mangrove 2",
    "Quarry",
    "Temple"
  ],
  "AllHellgateLevels": [
    "Hijawan",
    "Intro Island",
    "Kubor",
    "Mangrove 2",
    "Quarry",
    "Temple"
  ]
}
```
7. Save the configuration file, restart the game
8. The level filter will be applied starting from the next hell gate level

# FAQ
Q: There is a new level, how do I know it's name?

A: Delete the file and restart the game, the updated file with all level names will be generated


Q: What if I edit `AllHellgateLevels` field?

A: This field does not affect anything, it is just to display the level names 