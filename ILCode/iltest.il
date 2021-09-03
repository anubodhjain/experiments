//IL test
.assembly extern mscorlib {}

.assembly ILTest
{
	.ver 0:0:0:1
}

.module iltest.exe

.method static void temp() cil managed
{
	.maxstack 1
	.entrypoint
	
	ldstr "handcoding IL for the first time"
	call void [mscorlib]System.Console::WriteLine (string)
	ret
}

