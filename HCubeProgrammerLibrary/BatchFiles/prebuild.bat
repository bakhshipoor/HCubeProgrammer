del /q "$(ProjectDir)$(OutDir)*"
FOR /D %%p IN ("$(ProjectDir)$(OutDir)*.*") DO rmdir "%%p" /s /q