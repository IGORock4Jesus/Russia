struct Input {
	float4 color : COLOR;
};



float4 main(Input input) : SV_TARGET
{
	return input.color;
}