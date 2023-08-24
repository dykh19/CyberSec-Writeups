# Writeup

Malware sample obtained from Malware Bazaar (https://bazaar.abuse.ch)

## Basic Information

MD5: 55851693e0542072aacbd0c4cf5066f7

SHA256: 3013cff4c3e0feea59c67876526413c8d2bb2c6c9a13b76945a4ad624c1f9979

## Basic Static Analysis

### PEiD
PEiD shows that the sample is not packed.

### PEBear

PEBear shows the .reloc section has a virtual size of 0xC while the raw size is 0x200. The raw and virtual sizes of .text and .rsrc does not look suspicious.

The sample only imports one dll file, `mscoree.dll`.

In the Debug tab, there is a reference to a pdb file with the directory
`C:\Users\fbogner\Desktop\Desktop.old\DotNetDropper\BeeShellDotNetLauncher\BeeShellDotNetLauncher\obj\Debug\BeeShellDotNetLauncher.pdb`.

Perhaps this file is a dropper.

### Strings
Strings showed a suspicious looking hex string `150481494A7596B41D5D247557594F04CB4A7EDEF0FA24CCD48F5A1DE13CF1F8` however, decoding it to ascii in CyberChef did not yield results.

There is also a string `PowerShell`, perhaps there is some powershell scripting involved.

## Basic Dynamic Analysis

### Running without INetSim
Upon running, a console window appeared before disappearing.



