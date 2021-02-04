#pragma once

#include <wrl.h>
#include <d3d9.h>
#include "Vertex.h"

using namespace Microsoft::WRL;

class VertexBuffer {
	ComPtr<IDirect3DVertexBuffer9> com;

public:
	HRESULT Initialize(ComPtr<IDirect3DDevice9> device, Vertex* buffer, int count);
	void Render(ComPtr<IDirect3DDevice9> device);
};

