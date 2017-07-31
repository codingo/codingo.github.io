---
layout: post
title:  "Decompiling C# by Examle with Cracknet"
date:   2017-07-25 17:01:58 +1000
categories: reverse-engineering ctf
---

# What is Cracknet?
Back in May Brisbane SecTalks ran a capture the flag event where members of SecTalks contributed their own items for others to attempt to complete. As a part of this I built a .Net reverse engineering challenge, Cracknet. I've since made this available on Github, [here][cracknetrepo].

Although it's possible to complete this challenge by bypassing a JMP instruction in assembly the intention of this challenge was to introduce participants to decompiling .Net applications by patching the application.

# The initial load
When you first open CrackNet you're presented with the following:

![CrackNet First Load]({{ site.url }}/assets/2017-07-25-CrackNet/1-CrackNet-FirstLoad.PNG)



[cracknetrepo]: https://github.com/codingo/cracknet
