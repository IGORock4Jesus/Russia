struct Input {
	float4 position : POSITION;
	float4 color : COLOR;
};

struct Output {
	float4 position : SV_POSITION;
	float4 color : color;
};

Output main(Input input) {
	Output output;
	output.position = input.position;
	output.color = input.color;
	return output;
}