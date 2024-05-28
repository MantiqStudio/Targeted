# Targeted 🎯
## Targeting and simulation system
It is a system designed to know what the user relates to the user, or the user to the publication or product, or the publication or product to the other publication or the other product, through automatic emotional systems. This system depends on the large number of users and their interaction, as it is the one that decides the behaviors of everything.
![sasa](https://github.com/MantiqStudio/Targeted/assets/167381007/ad3c38c4-54e8-46cb-90cd-846977e87f8b)

# How to use 🪴
In the first use namespace:
```cs
using Targeted
```
for create new engine use this code:
```cs
Engine engine = new Engine();
```
for make new Target
```cs
Target target = new Target(engine);
```
> [!NOTE]
> The user, posts, and everything that interacts are all considered Target

When linking two targets, use this command to increase the link:
```cs
engine.Approximation(target1, target2, power);
```
When there is no correlation between two targets, use this command to reduce the correlation:
```cs
engine.Away(target1, target2, power);
```
