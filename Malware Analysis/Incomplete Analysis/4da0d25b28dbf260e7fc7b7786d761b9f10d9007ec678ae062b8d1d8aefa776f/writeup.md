# Writeup

Sample obtained from Malware Bazaar (http://bazaar.abuse.ch)

## 1. Initial Analysis

This sample was tagged as executable and redlinestealer, using `file` on the sample shows that it is a `PE32 executable`

Opening the sample with DetectItEasy shows that it is compiled C/C++.

Opening the file in PEiD shows that it has high entropy but is not able to detect a packer. Perhaps the data is obfuscated.

Using `strings` does not show much information other than some error messages and imported functions and some strings that look like they are obfuscated.

PEBear shows the sample imports some dlls:
```
KERNEL32.dll
USER32.dll
GDI32.dll
ole32.dll
```
I noticed the imported function `WriteFile`, perhaps this sample might be a dropper.

## 2. Basic Dynamic Analysis

### 2.1 TCP View

In TCP View, the sample can be seen attempting to connect to an ip `152.89.196[.]149:2920`. The sample will periodically attempt to connect to the same ip and port.

### Process Monitor

Although this program is supposed to be C/C++, process monitor shows that it is loading .NET Framework dlls such as `mscoreei.dll`. 


