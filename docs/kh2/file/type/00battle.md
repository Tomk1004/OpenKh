# [Kingdom Hearts II](../../index.md) - 00battle.bin

This is an essential file for booting [Kingdom Hearts II](../../index.md) and it contains everything related to the battle system.

It is a [BAR](bar.md) file and contains the following subfiles:

* [ATKP](#atkp) - Attack Params
* [PTYA](#ptya) - Party Attacks
* [PRZT](#przt) - Prize Table
* [VTBL](#vtbl) - Voice Table
* [LVUP](#lvup) - Level Up
* [BONS](#bons) - Bonus
* [BTLV](#btlv) - Battle Level
* [LVPM](#lvpm) - Level Params
* [ENMP](#enmp) - Enemy Params
* [PATN](#patn) - Pattern
* [PLRP](#plrp) - Player Params
* [LIMT](#limt) - Limits
* [SUMN](#sumn) - Summons
* [MAGC](#magc) - Magic
* [VBRT](#vbrt) - ???
* [FMLV](#fmlv) - Form Levels
* [STOP](#stop) - ???
* [0A](#0a) - ??? (3 entries)

## Atkp

Contains the parameters for the various actions in the game.
The damage effects' values on MSET files point to this table.

### Atkp Structure

| Amount | Description |
|--------|---------------|
| 1 	 | Atkp header
| 2713 	 | Atkp entries

### Atkp Header

| Offset | Variable Type | Description |
|--------|---------------|-------------|
| 0 	 | uint | File type (6)
| 4 	 | uint | Entry Count

### Atkp Entry

| Offset | Variable Type | Description |
|--------|---------------|-------------|
| 0 	 | ushort | SubId
| 2 	 | ushort | Id
| 4 	 | byte | Type (0 normal, 1 pierces armor...)
| 5 	 | byte | Critical Adjust (0 normal, 1 half damage, 2 no damage)
| 6 	 | ushort | Power
| 8 	 | byte | Team (Deal damage to: 0/1/2 Enemies, 3/4/5 Enemies and allies...)
| 9 	 | byte | Element (0 phys, 1 fire, 2 blizz, 3 thun...)
| 10 	 | byte | Reaction (Whether an enemy is flinched, knocked...)
| 11 	 | byte | Effect on hit (0 none, other values = different effects)
| 12 	 | short | Knockback Strength 1 (Distance depends on enemy weight)
| 14 	 | short | Knockback Strength 2 (Distance depends on enemy weight)
| 16 	 | short | ???
| 18 	 | byte | Flag (Eg: 20/22 can defeat bosses)
| 19 	 | byte | Refact Self
| 20 	 | byte | Refact Other
| 21 	 | byte | Reflected motion (Points to the slot in the MSET to be triggered when the attack is reflected)
| 22 	 | short | Reflect Hit Back
| 24 	 | int | Reflect Action
| 28 	 | int | Hit Sound Effect
| 32 	 | ushort | Reflect RC
| 34 	 | byte | Reflect Range
| 35 	 | sbyte | Reflect Angle
| 36 	 | byte | Damage Effect
| 37 	 | byte | Switch
| 38 	 | ushort | Interval (1 hit every X frames)
| 40 	 | byte | Floor Check
| 41 	 | byte | Drive drain (Adds on normal state, reduces when in a form)
| 42 	 | byte | Revenge damage
| 43 	 | byte | Tr Reaction
| 44 	 | byte | Combo Group
| 45 	 | byte | Random Effect
| 46 	 | byte | Kind
| 47 	 | byte | HP drain (Adds on normal state, reduces when in a form)

## Ptya

Contains data for the party's attacks.

Contains a list of pointers that point to the offset of a Ptya set. There are multiple pointers for multiple sets.
Ptya sets contain the list of attack animations a character use in certain situations in a combo.

### Ptya Structure

| Amount | Description |
|--------|---------------|
| 1 	 | Ptya header
| 70 	 | Ptya pointers
| 15 	 | Ptya sets

### Ptya Header

| Offset | Variable Type | Description |
|--------|---------------|-------------|
| 0 	 | uint | File type (2)
| 4 	 | uint | Pointer Count

### Ptya Set Structure

| Amount | Description |
|--------|---------------|
| 1 	 | Ptya Set Header
| X 	 | Ptya Set Entry

### Ptya Set Header

| Offset | Type  | Description
|--------|-------|--------------
| 0     | uint | Ptya Set Entry Count

### Ptya Set Entry

| Offset | Type  | Description
|--------|-------|--------------
| 0     | byte | Id
| 1     | byte | Type
| 2     | sbyte | Sub
| 3     | sbyte | Combo Offset
| 4     | uint | Flag
| 8     | ushort | Motion Id \*
| 10     | ushort | Next Motion Id \*
| 12     | float | Jump
| 16     | float | Jump Max
| 20     | float | Jump Min
| 24     | float | Speed Min
| 28     | float | Speed Max
| 32     | float | Near
| 36     | float | Far
| 40     | float | Low
| 44     | float | High
| 48     | float | Inner Min
| 52     | float | Inner Max
| 56     | float | Blend Time
| 60     | float | Distance Adjust
| 64     | ushort | Ability - SubId on [Item](./03System#Item)
| 66     | ushort | Score

\* Multiply by 4 to get the slot of the motion in the entity's [moveset file](../anb/mset.md).

## Przt

Contains the item drop table.
The ID of the entry is assigned in the AI of the object.

### Przt Structure

| Amount | Description |
|--------|---------------|
| 1 	 | Przt header
| 184 	 | Przt entries

### Przt Header

| Offset | Variable Type | Description |
|--------|---------------|-------------|
| 0 	 | uint | File type (2)
| 4 	 | uint | Entry Count

### Przt Entry

| Offset | Type  | Description
|--------|-------|--------------
| 00     | ushort | ID
| 02     | byte  | Small HP orbs
| 03     | byte  | Big HP orbs
| 04     | byte  | Big Money orbs
| 05     | byte  | Medium Money orbs
| 06     | byte  | Small Money orbs
| 07     | byte  | Small MP orbs
| 08     | byte  | Big MP orbs
| 09     | byte  | Small Drive orbs
| 0A     | byte  | Big Drive orbs
| 0B     | byte  | Unknown
| 0C     | ushort  | Item 1 (Refer to ITEM from 03system) - [ITEM/ABILITY LIST](../../dictionary/inventory.md)
| 0E     | short  | Item 1 Drop Percentage
| 10     | ushort  | Item 2 (Refer to ITEM from 03system) - [ITEM/ABILITY LIST](../../dictionary/inventory.md)
| 12     | short  | Item 2 Drop Percentage
| 14     | ushort  | Item 3 (Refer to ITEM from 03system) - [ITEM/ABILITY LIST](../../dictionary/inventory.md)
| 16     | short  | Item 3 Drop Percentage

## Vtbl

Contains data for randomizing voice clips.

### Vtbl Structure

| Amount | Description |
|--------|---------------|
| 1 	 | Vtbl header
| 241 	 | Vtbl entries

### Vtbl Header

| Offset | Variable Type | Description |
|--------|---------------|-------------|
| 0 	 | uint | File type (1)
| 4 	 | uint | Entry Count

### Vtbl Entry

| Offset | Type  | Description
|--------|-------|--------------
| 0 	 | byte | Character - [CHARACTER LIST](../../dictionary/characters.md)
| 1 	 | byte | Action 
| 2 	 | byte | Priority?
| 3 	 | byte | Padding?
| 4 	 | byte | Voice 1
| 5 	 | byte | Voice 1 Chance
| 6 	 | byte | Voice 2
| 7 	 | byte | Voice 2 Chance
| 8 	 | byte | Voice 3
| 9 	 | byte | Voice 3 Chance
| 10 	 | byte | Voice 4
| 11 	 | byte | Voice 4 Chance
| 12 	 | byte | Voice 5
| 13 	 | byte | Voice 5 Chance

## Lvup

Contains the level-up table for every playable character.
The Lvup entries follow this sequence:

### Character sequence

* Sora / Roxas
* Donald
* Goofy
* Mickey
* Auron
* Ping / Mulan
* Aladdin
* Sparrow
* Biest
* Jack
* Simba
* Tron
* Riku

NOTE: The first character pointer doesn't point to any character. May be some kind of padding.

### Lvup Structure

| Amount | Description |
|--------|---------------|
| 1 	 | Lvup header
| 13 	 | Character pointer
| 13 	 | Character

### Lvup Header

| Offset | Variable Type | Description |
|--------|---------------|-------------|
| 0 	 | uint | File type (2)
| 4 	 | uint | Character pointer count

### Character pointer

| Offset | Variable Type | Description |
|--------|---------------|-------------|
| 0 	 | uint | Offset of the character (Measured in 4 bytes, so 10 means offset 40)
| 4 	 | uint | Padding

### Character Structure

| Amount | Description |
|--------|---------------|
| 1 	 | Character header
| 99 	 | Lvup Entry

### Character header

| Offset | Type | Description |
|--------|------|-------------|
| 00     | uint  | Lvup entry count
| 04     | uint  | Padding

### Lvup Entry

| Offset | Type | Description |
|--------|------|-------------|
| 00     | int  | Needed EXP for next level
| 04     | byte | Strength of Character
| 05     | byte | Magic of Character
| 06     | byte | Defense of Character
| 07     | byte | AP of Character
| 08     | short | Ability given when using Sword route (03system.bin --> ITEM sub file) - [ITEM/ABILITY LIST](../../dictionary/inventory.md)
| 0A     | short | Ability given when using Shield route (03system.bin --> ITEM sub file) - [ITEM/ABILITY LIST](../../dictionary/inventory.md)
| 0C     | short | Ability given when using Staff route (03system.bin --> ITEM sub file) - [ITEM/ABILITY LIST](../../dictionary/inventory.md)
| 0E     | short | Padding

## Bons

Contains reward items (GET! BONUS).
The ID is assigned in the msn file (first sub file, offset 0xD).

### Bons Structure

| Amount | Description |
|--------|---------------|
| 1 	 | Bons header
| 179 	 | Bons entries

### Bons header

| Offset | Type | Description |
|--------|------|-------------|
| 00     | int32 | File type (2)
| 04     | int32 | Number of 'Bons' entries

### Bons entry

| Offset | Type  | Description
|--------|-------|--------------
| 00     | byte  | ID - [EVENT LIST](../../dictionary/events.md)
| 01     | byte  | Character Id
| 02     | byte  | HP Increase
| 03     | byte  | MP Increase
| 04     | byte  | Drive Gauge Upgrade
| 05     | byte  | Item Slot Upgrade
| 06     | byte  | Accessory Slot Upgrade
| 07     | byte  | Armor Slot Upgrade
| 08     | short | Bonus Item 1 (Refer to ITEM from 03system) - [ITEM/ABILITY LIST](../../dictionary/inventory.md)
| 10     | short | Bonus Item 2 (Refer to ITEM from 03system) - [ITEM/ABILITY LIST](../../dictionary/inventory.md)
| 12     | int   | Unknown

## Btlv

???

### Btlv Structure

| Amount | Description |
|--------|---------------|
| 1 	 | Btlv header
| 20 	 | Btlv entries

### Btlv Header

Contains the table for battle level of each world. Whether each entry is enabled or not is determined by a bitmask and the final battle level will be the sum of all of the world's enabled battle lv entries.

| Offset | Variable Type | Description |
|--------|---------------|-------------|
| 0 	 | uint | File type (1)
| 4 	 | uint | Entry Count

### Btlv Entry

| Offset | Type  | Description
|--------|-------|--------------
| 0 	 | uint  | Entry Index
| 4      | byte[2] | Unknown
| 6      | byte  | World ZZ
| 7      | byte  | World of Darkness
| 8      | byte  | Twilight Town
| 9      | byte  | Destiny Islands
| A      | byte  | Hollow Bastion
| B      | byte  | Beast's Castle
| C      | byte  | Olympus Coliseum
| D      | byte  | Agrabah
| E      | byte  | Land of Dragons
| F      | byte  | 100 Acre Woods
| 10     | byte  | Pride Lands
| 11     | byte  | Atlantica
| 12     | byte  | Disney Castle
| 13     | byte  | Timeless River
| 14     | byte  | Halloween Town
| 15     | byte  | World Map
| 16     | byte  | Port Royal
| 17     | byte  | Space Paranoids
| 18     | byte  | The World that Never Was
| 19     | byte[7] | Unknown

## Lvpm

Contains the level-up table for the enemies. Based on the level of an enemy, a specific level, containing multiplying values, will be applied over the base statistics of an enemy.

### Lvpm Structure

| Amount | Description |
|--------|---------------|
| 99 	 | Lvpm entries

### Lvpm Entry

| Offset | Type  | Description
|--------|------ |--------------
| 00     | short | HP level. The formula is `(EnemyHp * LevelHp + 99) / 100`.
| 02     | short | Strength
| 04     | short | Defense
| 06     | short | ???
| 08     | short | ???
| 0A     | short | Exp

## Enmp

Contains enemy statistics.

All the weaknesses are represented in percentage unit. So a weakness with the value of 100 represents that the damage received is unfiltered. 200 the enemy receives double of the damage for that specific element, while 0 nullifies it.

A single enemy has also 32 different HP units, where the first one is the HP of the main entity. Some enemies uses the other 31 entries too, but their purpose is currently unknown.

Every enemy is associated to one or more IDs (eg. Organization members have different ID based if they are in their first fight or they are their data version). Different enemies can use the same ID. The way the game associates an ID to a specific MDLX is done by AI scripting.

### Enmp Structure

| Amount | Description |
|--------|---------------|
| 1 	 | Enmp header
| 229 	 | Enmp entries

### Enmp Header

| Offset | Variable Type | Description |
|--------|---------------|-------------|
| 0 	 | uint | File type (2)
| 4 	 | uint | Entry Count

### Enmp Entry

| Offset | Type  | Description
|--------|------|--------------
| 00     | short | Identifies the enemy. - [Enemy LIST](../../dictionary/enemy.md)
| 02     | short | Level of the enemy. Must be between 1 and 99. (0 uses the world's battle level)
| 04     | short[32] | Health amount. It is multiplied by Hp from [LVPM](#lvpm).
| 44     | short | Damage Cap. (The higher, the less damage received)
| 46     | short | ???
| 48     | short | Physical weakness.
| 4A     | short | Fire weakness.
| 4C     | short | Blizzard weakness.
| 4E     | short | Thunder weakness.
| 50     | short | Dark weakness.
| 52     | short | Neutral weakness.
| 54     | short | General weakness.
| 56     | short | Exp multiplier.
| 58     | short | Unknown
| 5A     | short | Unknown

## Patn

Defines multiple parameters per group of entities. How an entity is assigned to a group is unknown.
EG: 05 is Mad Rider, 14 is Reckless, Xaldin, 15 is Morning Star, Assault Rider, Living Bones, Berserker...

### Patn Structure

| Amount | Description |
|--------|---------------|
| 1 	 | Patn header
| 18 	 | Patn entries

### Patn Header

| Offset | Variable Type | Description |
|--------|---------------|-------------|
| 0 	 | uint | File type (2)
| 4 	 | uint | Entry Count

### Patn Entry

| Offset | Type  | Description
|--------|------|--------------
| 00     | byte | Id
| 01     | byte | ???
| 02     | byte | ???
| 03     | byte | ???
| 04     | byte | ???
| 05     | byte | Magnet Burst effect\*
| 06     | byte | Magnet\*
| 07     | byte | ???
| 08     | byte | ???
| 09     | byte | ???
| 10     | byte | ???
| 11     | byte | ???
| 12     | byte | ???
| 13     | byte | ???
| 14     | byte | ???
| 15     | byte | ???
| 16     | byte | ???
| 17     | byte | ???
| 18     | byte | ???
| 19     | byte | ???
| 20     | byte[12] | Padding

\* (00 is immune, 01/0C/0D draws in, 02/03 flinches, 04/07/09/0B knocks out, 05 pulls in(magnet), 06/08/0A is flinch + draw, 0E is flinch + insta revenge...)

## Plrp

Contains informations about starting Character statistics, starting Abilities etc.

### Plrp Structure

| Amount | Description |
|--------|---------------|
| 1 	 | Plrp header
| 64 	 | Plrp entries

### Plrp Header

| Offset | Variable Type | Description |
|--------|---------------|-------------|
| 0 	 | uint | File type (2)
| 4 	 | uint | Entry Count

### Plrp Entry

| Offset | Type  | Description
|--------|-------|--------------
| 00     | short | Unknown
| 02     | byte  | Character ID - [Character LIST](../../dictionary/characters.md)
| 03     | byte  | HP
| 04     | byte  | MP
| 05     | byte  | AP
| 06     | short | Unknown
| 08     | short | Unknown
| 0A     | short | Unknown
| 0C     | short[58] | Starting items (abilities, magic etc. Refer to ITEM from 03system*). These are obtained after the dusks fight in Station of Awakening. - [ITEM/ABILITY LIST](../../dictionary/inventory.md)

NOTE: Abilities that are enabled by default begin with an 8.

## Limt

Data on limits.

### Limt Structure

| Amount | Description |
|--------|---------------|
| 1 	 | Limt header
| 64 	 | Limt entries

### Limt Header

| Offset | Variable Type | Description |
|--------|---------------|-------------|
| 0 	 | uint | File type (2)
| 4 	 | uint | Entry Count

### Limt Entry

| Offset | Type  | Description
|--------|-------|--------------
| 00     | byte | ID
| 01     | byte  | Character - [Character/Summon LIST](../../dictionary/characters.md)
| 02     | byte  | Summon - [Character/Summon LIST](../../dictionary/characters.md)
| 03     | byte  | Group (3 requires all of the characters to be alive)
| 04     | char[32]  | Filename
| 36     | ushort | Spawn - [OBJ LIST](../../dictionary/obj.md)
| 38     | byte[2] | Padding
| 40     | ushort | Command - [Command LIST](../../dictionary/commands.md)
| 42     | ushort | Limit - [ITEM/ABILITY LIST](../../dictionary/inventory.md)
| 44     | byte | Used for Timeless River versions (0D) (May be more bytes)
| 45     | byte[19] | Padding

## Sumn

Data on summons.

### Sumn Structure

| Amount | Description |
|--------|---------------|
| 1 	 | Sumn header
| 4 	 | Sumn entries

### Sumn Header

| Offset | Variable Type | Description |
|--------|---------------|-------------|
| 0 	 | uint | File type (2)
| 4 	 | uint | Entry Count

### Sumn Entry

| Offset | Type  | Description
|--------|-------|--------------
| 0     | ushort | Summon - [Command LIST](../../dictionary/commands.md)
| 2     | ushort | Item - [ITEM/ABILITY LIST](../../dictionary/inventory.md)
| 4     | uint | Entity Spawned 1 - [OBJ LIST](../../dictionary/obj.md)
| 8     | uint | Entity Spawned 2 - [OBJ LIST](../../dictionary/obj.md)
| 12     | ushort | Limit - [Command LIST](../../dictionary/commands.md)
| 14     | byte[50] | Padding

## Magc

Data on magic.

### Magc Structure

| Amount | Description |
|--------|---------------|
| 1 	 | Magc header
| 36 	 | Magc entries

### Magc Header

| Offset | Variable Type | Description |
|--------|---------------|-------------|
| 0 	 | uint | File type (1)
| 4 	 | uint | Entry Count

### Magc Entry

| Offset | Type  | Description
|--------|-------|--------------
| 0     | byte | Type
| 1     | byte | Level
| 2     | 2B | ???
| 4     | char[32] | Filename
| 36     | 2B | ???
| 38     | short | Command - [Command LIST](../../dictionary/commands.md)
| 40     | short | Ground motion - [Motion LIST](../../file/anb/mset.html)
| 42     | short | Ground ???
| 44     | short | Finish motion
| 46     | short | Finish ???
| 48     | short | Air motion
| 50     | short | Air ???
| 52     | byte | ???
| 53     | byte | ???
| 54     | byte | ???
| 55     | byte | Padding

## Vbrt

[BAR](bar.md) file containing unknown data.

* vibr
* auto
* bliz
* v0lo
* l_bo (2 entries)

## Fmlv

Contains the level-up table for summons and drive forms.

### Fmlv Structure

| Amount | Description |
|--------|---------------|
| 1 	 | Fmlv header
| 45 	 | Fmlv entries

### Fmlv Header

| Offset | Variable Type | Description |
|--------|---------------|-------------|
| 0 	 | uint | File type (2)
| 4 	 | uint | Entry Count

### Fmlv Entry

| Offset | Type  | Description
|--------|-------|-------------
| 00     | byte  | First digit is the Form id, second digit is the Form level (e.g. 0x13 is Valor Form Level 3)
| 01     | byte  | Level of the movement ability in the form (High Jump, Quick Run etc.)
| 02     | short | Ability obtained through level up - [ITEM/ABILITY LIST](../../dictionary/inventory.md)
| 04     | int   | EXP needed for level up

### Forms

Standard (JP/US/EU)

| ID | Form
|----|-----
| 00 | Summon
| 01 | Valor
| 02 | Wisdom
| 03 | Master
| 04 | Final
| 05 | Anti

Final Mix (JP/PS3/PS4)

| ID | Form
|----|-----
| 00 | Summon
| 01 | Valor
| 02 | Wisdom
| 03 | Limit
| 04 | Master
| 05 | Final
| 06 | Anti

## Stop

Data on unknown

### Stop Structure

| Amount | Description |
|--------|---------------|
| 1 	 | Stop header
| 4 	 | Stop entries

### Stop Header

| Offset | Variable Type | Description |
|--------|---------------|-------------|
| 0 	 | uint | File type (1)
| 4 	 | uint | Entry Count

### Stop Entry

| Offset | Type  | Description
|--------|-------|-------------
| 00     | ushort  | ID
| 02     | ushort  | ???


## 0A

Unknown.
