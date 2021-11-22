# DummyClang
## Summary
Used to forcibly chanfe the arguments passed to clang++
## How to use
Replace the original`clange++.exe`to`_clang++.exe` and place the `clang++.exe` that was built in this project instead.
Currently, `-fvisibility=default`is deleted from the argument. Please modify the following part if necessary.
 

```
 static string[,] replaceWordTbl = new string[,]
        {
          {"-fvisibility=default",""}, // Replacement Option
 };
 ```
