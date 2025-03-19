<h1 align="center">TechQuest: Knowledge Challenge</h1>
<p align="center">My VB.NET school assignment, a simple examination system.</p>

## Table of Contents
- [Notes](#notes)
- [Flowchart](#flowchart)
- [Download](#download)

## Notes
- Please ignore yucky code, it just works.
	- There is (hopefully) enough comments in the code to understand what's going on. I will NOT bother re-checking as my brain will explode from seeing my unformatted, unclean mess.

## Flowchart
```mermaid
flowchart TD
    A[START] --> B[Launch application]
    B --> C[Welcome screen - Introduction & Instructions]
    C --> D[Enter username]
    D --> E{If username is entered}
    E -- No --> F["Error message: please enter a username"]
    F --> D
    E -- Yes --> G[Click start button]
    G --> H[Examination screen]
    H --> I[Answer questions - x15]
    I --> J[Submit answers]
    J --> K[View score and feedback]
    K --> L[Open leaderboard]
    L --> M{Leaderboard outcomes}
    M -- Review questions --> N[Review questions]
    M -- See global leaderboard --> O[See global leaderboard]
    M -- Close leaderboard --> P[Close leaderboard]
    P --> Q{Close leaderboard outcomes}
    Q -- Retry --> C
    Q -- Exit --> R[END]
```


## Download
You can download a **compiled release** from [here](https://github.com/NoobToolzz/TechQuest/releases/latest/download/TechQuest-compiled.zip).