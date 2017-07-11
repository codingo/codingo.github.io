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

Although this is usually quite an easy problem to resolve for some reason Visual Studio isn’t showing the diff tool and allowing me to resolve the conflicts.

Thankfully as we’re using git for our version control backend this is quite easy to resolve in the backend.

To overcome this first open a new command line window for the repository where the conflict is.

First navigate to the synchronization page which shows you incoming and outgoing commits. In the window that appears click _Actions_ and then _Open in Command Prompt._

![Git pull conflict]({{ site.url }}/assets/2014-05-27-Conflict-Prevents-Checkout/Git-Sync-Window.png)


