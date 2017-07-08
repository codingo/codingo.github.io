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
