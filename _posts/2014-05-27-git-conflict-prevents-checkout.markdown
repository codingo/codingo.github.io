---
layout: post
title:  "An error occurred. Detailed message: 1 conflict prevents checkout when doing a GIT pull request in Visual Studio"
date:   2014-05-27 17:01:58 +1000
categories: git visual-studio
---
I’ve noticed something interesting happening in Visual Studio 15 when I move between environments and try to do a pull request.

I’m able to see the incoming commits queue as well as the content within them but when I go to do a pull request I’ll receive the error:
```
An error occurred. Detailed message: 1 conflict prevents checkout
```

This problem occurs when you try to checkout a file on a branch in your local repository but is out of sync with the same branch on the remote repository (sidenote: stop working directly in master and this issue is nearly always gone!).

Although this is usually quite an easy problem to resolve for some reason Visual Studio won't show the diff tool in this scenario, nor will it allow a pull request within the GUI to update a local repository.

Thankfully as we’re using git for our version control backend this is quite easy to resolve in the backend.

To overcome this first open a new command line window for the repository where the conflict is.

To do this navigate to the synchronization page which shows you incoming and outgoing commits. In the window that appears click _Actions_ and then _Open in Command Prompt._

![Git pull conflict]({{ site.url }}/assets/2014-05-27-Conflict-Prevents-Checkout/Git-Sync-Window.png)

You then want to perform a ```git status``` command to confirm that you have outstanding changes to pull from the remote branch.

![Git Status]({{ site.url }}/assets/2014-05-27-Conflict-Prevents-Checkout/Git-Status.png)
  
Then do a ```git pull``` to manually pulldown the latest commits to the branch to your local repository. In ordier to do successfully perform a pull request you will also need to enter alternative access credentials. If you don’t already have these (or know them) then logging into your Visual Studio Online page, managing your profile (top right) and setting them on Security will create the credentials you need whenever using git from the console window.
