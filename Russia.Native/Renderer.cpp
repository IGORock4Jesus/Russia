#include "Renderer.h"
#include <thread>
#include "Vertex.h"

using namespace Microsoft::WRL;

ComPtr<IDirect3D9> direct;
ComPtr<IDirect3DDevice9> device;

std::thread thread;
bool enabled;


void RenderThread() {
	while (enabled) {
		device->Clear(0, nullptr, D3DCLEAR_TARGET | D3DCLEAR_ZBUFFER | D3DCLEAR_STENCIL, 0xff444444, 1.0f, 0);
		device->BeginScene();

		device->SetFVF(D3DFVF_XYZRHW | D3DFVF_DIFFUSE);
		Vertex vs[] = {
			{ 100.0f, 100.0f, 0.0f, 0.0f, 0xffff0000 },
			{ 300.0f, 100.0f, 0.0f, 0.0f, 0xff0ff000 },
			{ 300.0f, 300.0f, 0.0f, 0.0f, 0xff00ff00 },
			{ 100.0f, 300.0f, 0.0f, 0.0f, 0xff0000ff },
		};
		device->DrawPrimitiveUP(D3DPT_TRIANGLEFAN, 2, vs, sizeof(Vertex));

		device->EndScene();
		device->Present(nullptr, nullptr, nullptr, nullptr);
	}
}

bool InitializeRenderer(HWND hwnd, int width, int height) {

	if (!(direct = Direct3DCreate9(D3D_SDK_VERSION))) {
		return false;
	}

	D3DPRESENT_PARAMETERS pp{ 0 };
	pp.BackBufferWidth = width;
	pp.BackBufferHeight = height;
	pp.BackBufferCount = 1;
	pp.SwapEffect = D3DSWAPEFFECT_DISCARD;
	pp.Windowed = true;
	pp.hDeviceWindow = hwnd;
	pp.BackBufferFormat = D3DFMT_A8R8G8B8;
	pp.AutoDepthStencilFormat = D3DFMT_D24S8;
	pp.EnableAutoDepthStencil = true;

	direct->CreateDevice(0, D3DDEVTYPE_HAL, hwnd, D3DCREATE_HARDWARE_VERTEXPROCESSING | D3DCREATE_MULTITHREADED, &pp, device.GetAddressOf());

	if (!device) {
		return false;
	}

	device->SetRenderState(D3DRS_LIGHTING, FALSE);

	enabled = true;
	thread = std::thread(RenderThread);

	return true;
}

void ReleaseRenderer() {
	enabled = false;
	if (thread.joinable()) {
		thread.join();
	}
	device = nullptr;
	direct = nullptr;
}

Microsoft::WRL::ComPtr<IDirect3DDevice9> GetDevice() {
	return device;
}
