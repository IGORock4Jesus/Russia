#pragma once

#include <vector>
#include <D3D11.h>
#include <D3DX10.h>

struct Vertex {
	D3DXVECTOR3 position;
	D3DXCOLOR color;

	/*static const DWORD FVF;
	static const DWORD SIZE;*/
};

const std::vector<D3D11_INPUT_ELEMENT_DESC>& GetVertexLayout(); 
