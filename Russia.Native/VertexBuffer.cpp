#include "VertexBuffer.h"

HRESULT VertexBuffer::Initialize(ComPtr<IDirect3DDevice9> device, Vertex* buffer, int count) {
	HRESULT result = S_OK;
	/*IDirect3DVertexBuffer9** address = com.GetAddressOf();
	if (FAILED(result = device->CreateVertexBuffer(Vertex::SIZE * count, D3DUSAGE_WRITEONLY, Vertex::FVF, D3DPOOL_MANAGED, address, nullptr))) {
		return result;
	}
	void* data = nullptr;
	if (FAILED(result = com->Lock(0, 0, &data, 0))) {
		return result;
	}
	memcpy(data, buffer, Vertex::SIZE * count);
	return com->Unlock();*/
	return result;
}

void VertexBuffer::Render(ComPtr<IDirect3DDevice9> device) {
	if (!com) {
		return;
	}
	/*device->SetFVF(Vertex::FVF);
	device->SetStreamSource(0, com.Get(), 0, Vertex::SIZE);
	device->DrawPrimitive(D3DPT_TRIANGLEFAN, 0, 2);*/
}
