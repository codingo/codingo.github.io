---
layout: post
title:  "CrikeyCon 2017 - Impossible Math Writeup"
date:   2017-03-08 17:10:58 +1000
categories: ctf writeup programming
---
```Category: Coding
Points: 400
Solves: 7
Description:  ctf.crikeycon.com:43981```

# Enumeration
Before doing anything else on the host since we were provided with an unual port and address I attempted to ncat to it, receiving the following:

![Impossible Math Preview]({{ site.url }}/assets/2017-03-08-Impossible-Math-Writeup/ImpossibleMath-Preview.png)

# Identifying the core problem
Since the math is impossible there’s likely a trick here. With that in mind I figure we need to overload an operator (integer overflow) and try passing a large number as input:

![Impossible Math Overflow Check]({{ site.url }}/assets/2017-03-08-Impossible-Math-Writeup/OverflowCheck.png)

Awesome! Our integer overloads by wrapping around. To gather a bit more information I also tried an integer underflow:

![Impossible Math Underflow Check]({{ site.url }}/assets/2017-03-08-Impossible-Math-Writeup/UnderflowCheck.png)

The same result. I now had to identify the figure we wrap around. These numbers are a bit irritatingly long to work with so I tried something a bit smaller to see if I could something more manageable:

![Impossible Math Manageable Numbers]({{ site.url }}/assets/2017-03-08-Impossible-Math-Writeup/ManageableNumbers.png)

We can use the following to identify our overflow point:

![Impossible Math Manageable Numbers]({{ site.url }}/assets/2017-03-08-Impossible-Math-Writeup/OverflowFormula.png)

4294967296 is exactly 2^32, which is 1 beyond the maximum supported by unsigned int (32 bits), further supporting our case that this is an integer overflow exercise.

To validate this, I should be able to pass this value to any problem and receive 0 back as a response (as it will reach the signed amount and loop back once), as follows:

![Impossible Math Manageable Numbers]({{ site.url }}/assets/2017-03-08-Impossible-Math-Writeup/ZeroTest.png)

For the remainder of this exercise I’m going to refer to the variables from our second-last screenshot as the following:

![Impossible Math Manageable Numbers]({{ site.url }}/assets/2017-03-08-Impossible-Math-Writeup/Variables.png)

Since our number wraparounds we now know we need a number with the following conditions:

* Our overflow must be lower than 4294967296 but higher than our destination to pass the first condition.
* Our overflow needs to exceed 4294967296 when multiplied by the multiplier and result in the destination

# Calculating the correct overflow

As a reminder, we can calculate our overflow using the formula from earlier:

![Impossible Math Formula]({{ site.url }}/assets/2017-03-08-Impossible-Math-Writeup/VerboseVariables.png)

I turned this into a proof of concept by generating a new ncat session, which asked the following:

{% highlight text %}
Solve for X, where:
X > 37864
X * 8 = 37864
{% endhighlight %}

To generate our answer, I used the following:

{% highlight python %}
python -c 'print((2**32+destination)/multiplier)'
{% endhighlight %}

This generated the answer of 536875645 as follows:

![Impossible Math First Answer]({{ site.url }}/assets/2017-03-08-Impossible-Math-Writeup/FirstAnswer.png)



I hope this helped you to better understand integer overflows. If you're Brisbane based, or find yourself here be sure to check out [SecTalks][sectalks]



[sectalks]: https://www.meetup.com/en-AU/SecTalks-Brisbane/
