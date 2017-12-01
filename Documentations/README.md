# Documentations

## 0. Table of Contents
```
1. General Guideline for Repository
2. Git Conflicts
2-1. Reverting to Last Version
2-2. Re-Cloning Repository
3. Pull Request Rejection
4. General Guideline for Scripts
5. Naming Convention
6. Setup Image for Prefabs
7. Project Board
8. Milestone
9. Script Design Guideline
```

## 1. General Guideline for Repository

After each meeting, main repository needs to be updated by team manager. From there, team members can pull request to update their repository.  
Unless otherwise notified in the group message, general repository update process for each team member would be;

```
1. Team manager will merge and organize pulled files from each team member within main repository
2. Team manager will SEND pull request from main repository to each member's forked repository
3. Team member will pull the request, updating their repository to main repository.
4. Team member will work on their task until THURSDAY.
5. Before THURSDAY, 11:59PM, each team member will pull main repository to their repository  
to sync each team member's repository, in case main repository was changed over the week.
6. Before FRIDAY, 12:00AM, ALL team member will send pull request to main repository,  
regardless of completion of their task.
7. Team manager will pull each request, getting it ready for discussion on Friday.
8. After meeting, team manager will merge and organize files.
9. Repeat from 1.
```
__Do NOT start on your task before Saturday, as team manager tries to update main repository up-to-date before any pull is made. A good rule of thumb on when to start work on your task is when team manager sends you the pull request from main repository to team members' forked repository.__

Note that if you fail to send pull request for your task before Friday, it won't be accepted until next Thursday to prevent any conflict. This means each team member will have to __create local backup for their own task in case of getting their files overwritten by main repository files!__

## 2. Git Conflicts

Git alerts you if a single file is edited by two differnt fork/branches and sent pull request to master. In team manager's perspective, this is completely normal and team manager will manually merge and organize files. However, when team manager sent pull request to each team member's and get conflicts, this means team member's repository has been modified before main repository has been updated. If this occurs, you have two options; revert to previous version before pull or re-clone repository.

### 2-1. Reverting to Last Version

__Warning: If you have any new features added to your forked repository, BACKUP before you proceed!__

To revert back to last version;
```
1. Go to forked git repository via web browser, then click Pull Requests tab.
2. Click on Closed pull request
3. You will see list of closed pull request you accepted. Click on last version you pulled.
4. Scroll to bottom of pull request page, and you will see small Revert button.
5. Click on Revert button. This will take you to create new pull request page.  
Revert cannot be done unless reverted version is pulled.
```
You may also revert back to previous commit;
```
1. Go to forked git repository via github GUI, then click on History button
2. From the list of previous change. Right-click on the commit you wish to revert to.
3. Click on Revert this commit button. This will create new commit to previous version.
```

Once you have reverted to last version, you may be able to pull new version without any conflict.  
If this fails, you have an option to re-clone repository.

### 2-2. Re-clone Repository

__Warning: If you have any new features added to your forked repository, BACKUP before you proceed!__

__Caution: Re-cloning repository should only be used when conflicts cannot be resolved via reverting to last version.__

```
1. From github GUI, make sure you have GDC2017Project repository selected.
2. From top menu, click Repository -> Remove. This will remove repository from your local machine.
3. Go to folder where you had your repository cloned. You must remove main folder manually.
4. From github web browser, go to forked repository and go to Settings tab.
5. From Options, scroll down to bottom where you will find Danger Zone.
6. Click on Delete this repository. This will completely remove forked repository from your remote host.
7. Re-fork main repository, then re-clone repository to your local machine.
```

Re-cloning repository almost always works, but be sure to backup your local data as this will remove all your local changes.

## 3. Pull Request Rejection

Pull request will be __rejected under following reasons;__ (Changes will be made frequently as needed!)

```
1. Script is missing/have improper comment header section
2. Script is missing ComponentMenu
3. Prefab is not properly named for organizing perpose
4. Any prefab is missing setup image
5. Any file is not within appropriate folder
```

If your pull request is rejected for this week, you may send pull request again, but it won't be accepted until next pull due.

## 4. General Guidelines for Scripts

When writing scripts, it is highly recommanded to have separate script file. This prevents any conflicts in existing scripts. Allow your  team manager to manually merge and re-organize script.

For any new scripts, comment header section is __mendatory__. Missing a header section is on major reason your pull request getting rejected.

Comment header section provides information about who wrote initial version on what date and who edited on what date. You can copy the comment header section below to use it;

```
/*
 * Name_Of_Script.cs
 * 
 * Created By: Initial of personnel created
 * Created On: Date this script is created
 * Last Edited By: Initial of personnel edited last time
 * Last Edited On: Date this script is last edited
 *
 */
```

Component menu is critical for this project; this allows us to easily pick and place our scripts to game objects. However, you do NOT need to create component menu for every single script; only the script that is being used by game objects need component menu.

For example, Character.cs does not have component menu because it is inherited by Player.cs, Enemy.cs, and NPC.cs. In this case, only Player.cs, Enemy.cs, and NPC.cs will have component menu as they will be used by actual game objects.

Below is example for valid naming for Component Menu

```
1. GDC/Character/Player
2. GDC/World/Object/Breakable Object
3. GDC/Item/Armour
```

Note that file name is descending. __Be sure to add GDC before any component menu name!__

## 5. Naming Convention

Naming convention is critical for this project as well; this allows organization of prefabs and other files. However, scripts does not need strict naming convention as they will have component menu for ease of access. Following files MUST have strict naming convention;

```
1. Prefabs
2. Animations
3. Animators
4. Scenes
5. Sounds
6. Sprites (Except testing ones for quick prototyping)
```

To name your files, simply start with top-most branch then move down. For example, for animations;

```
animation_player_idle.anim
animation_player_jump.anim
animation_player_run.anim
animation_enemy_death.anim
```

Note that actual folder does not have `animation_` in front; this is because all animations are already inside animations folder.

Below is example for INVALID naming for files

```
npc_char_someone.prefab
(Invalid. NPC is subpart of Character; valid file name would be char_npc_someone.prefab)

char_someone_npc.prefab
(Invalid. someone is subpart of NPC; valid file name would be char_npc_someone.prefab)

spear1_weapon_item.prefab
(Invalid. Naming is ascending order; valid file name would be item_weapon_spear1.prefab)

sprite_box.png
(Invalid. Box is subpart of Sprite, but does not have its immediate parent;  
valid file name would be sprite_item_box.png)

bgm1.ogg
(Invalid. Even though file is under sound, if its subpart of bgm, bgm must be specified;  
valid file name would be bgm_bgm1.ogg)
```

As more and more file for different part of game is added, each file will have more subparts.  
This will be done at team manager level; however, when sending pull request, it is up to team members to have minimum naming convention.

## 6. Setup Image for Prefabs

As our prefabs transfer without meta data, it is crucial to have setup image for each prefab made.  
Simply take a screen shot and put saved image in `Documentations/Setup_Images`.  
Be sure to name files with prefab name __AT LEAST__ when saving image files.

## 7. Project Board

__Note: Starting November 24th, 2017, all tasks are distributed via Project Board__  

Project board is used to show overview of project and tasks; `TO DO`, `IN WORK`, and `COMPLETED` tags are used to indicate which task is at what state. Team member is responsible to choose which task to work on. It is completely up to team member's job to pick which task to work on. Project board will also have issues for functions if a function have bug. You can click on each task to see details and requirements for each task.

Be sure to notify team manager on which task you will be working on; this will let other team member know which task is being worked and avoid duplicate workload. Once team manager acknowledge your task, your initial will be added to task as tag, then task will change to `IN WORK` state.  

Once team manager acknowledge your task is completed, task will be marked as `COMPLETED` and will be marked closed. If any bug is found later, it will be added as new task on project board, with `Bug` tag.

To identify which task is still open, check if task card has green exclamation point on it. If task card has red exclamation point with checkmark, it meas that task is finished and sent to closed task. Any task can be opened again if the task was incomplete. So be sure to check project board often to see which task is still open.

## 8. Milestone

__Note: Starting November 24th, 2017, all tasks are priortized via Milestones__

Milestone is used to show overview of project completion and priority of tasks. Milestone will show overall completion with percentage and has tasks priortized in descending order. Which means tasks on top of the Milestone is number one priority in overall project. Priority list is not mendatory; it is suggestion.

If team member picks a task that is not on top of list, selected task will be move to top of the Milestone. Completed task will be removed from Milestone list, and will be moved to completed list.

## 9. Script Design Guidline

Whenever writing a script, be sure to write a script such that level design team has ease-of-access to vital controls. That is, setting up positions, destructible, speed, delay, weapon setting, etc.. Level design team should not be writing scripts, unless otherwise it is required for exclusive game objects. To give an example, when writing script for moving platform, after completing the script, following settings should be accessible for level design team;
```
1. Starting position
2. Surface condition
3. Platform delay
4. Horizontal Speed
5. Vertical Speed
6. Enable/disable horizontal movement
7. Enable/disable vertical movement
8. Mulitple vector position for multi-positional platform
```

Level design may ask to add/remove certain features, but until level design starts working on level consturction, think of all possible features needed for single script.
