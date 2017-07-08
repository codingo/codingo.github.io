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

![Impossible Math Manageable Numbers]({{ site.url }}/assets/2017-03-08-Impossible-Math-Writeup/OerflowFormula.png)

4294967296 is exactly 2^32, which is 1 beyond the maximum supported by unsigned int (32 bits), further supporting our case that this is an integer overflow exercise.

To validate this, I should be able to pass this value to any problem and receive 0 back as a response (as it will reach the signed amount and loop back once), as follows:

![Impossible Math Manageable Numbers]({{ site.url }}/assets/2017-03-08-Impossible-Math-Writeup/ZeroTest.png)



{% highlight ruby %}
def print_hi(name)
  puts "Hi, #{name}"
end
print_hi('Tom')
#=> prints 'Hi, Tom' to STDOUT.
{% endhighlight %}

Check out the [Jekyll docs][jekyll-docs] for more info on how to get the most out of Jekyll. File all bugs/feature requests at [Jekyll’s GitHub repo][jekyll-gh]. If you have questions, you can ask them on [Jekyll Talk][jekyll-talk].

[jekyll-docs]: https://jekyllrb.com/docs/home
[jekyll-gh]:   https://github.com/jekyll/jekyll
[jekyll-talk]: https://talk.jekyllrb.com/
