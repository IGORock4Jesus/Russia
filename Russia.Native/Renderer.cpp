#include "Renderer.h"
#include <thread>
#include "Vertex.h"
#include "VertexBuffer.h"

using namespace Microsoft::WRL;
using namespace std::chrono_literals;

ComPtr<IDXGISwapChain> swapChian;
ComPtr<ID3D11Device> device;
ComPtr<ID3D11DeviceContext> deviceContext;
ComPtr<ID3D11RenderTargetView> renderTargetView;

std::thread thread;
bool enabled;


void RenderThread() {
	while (enabled) {
		float color[]{ 0.2f, 0.2f, 0.2f, 1.0f };
		deviceContext->ClearRenderTargetView(renderTargetView.Get(), color);

		swapChian->Present(0, 0);

		std::this_thread::sleep_for(0s);
	}
}

HRESULT InitializeRenderer(HWND hwnd, int width, int height) {
	HRESULT result = S_OK;

	DXGI_MODE_DESC modeDesc{ 0 };
	modeDesc.Width = width;
	modeDesc.Height = height;
	modeDesc.Format = DXGI_FORMAT_R8G8B8A8_UNORM;
	modeDesc.RefreshRate = { 1,60 };
	
	DXGI_SWAP_CHAIN_DESC swapChainDesc{ 0 };
	swapChainDesc.BufferCount = 1;
	swapChainDesc.BufferDesc = modeDesc;
	swapChainDesc.SampleDesc = { 1,0 };
	swapChainDesc.BufferUsage = DXGI_USAGE_RENDER_TARGET_OUTPUT;
	swapChainDesc.OutputWindow = hwnd;
	swapChainDesc.Windowed = TRUE;
	swapChainDesc.SwapEffect = DXGI_SWAP_EFFECT_DISCARD;

	if (FAILED(result = D3D11CreateDeviceAndSwapChain(nullptr, D3D_DRIVER_TYPE_HARDWARE, nullptr, 0, nullptr, 0, D3D11_SDK_VERSION, &swapChainDesc, swapChian.GetAddressOf(), device.GetAddressOf(), nullptr, deviceContext.GetAddressOf()))) {
		return result;
	}

	ComPtr<ID3D11Texture2D> backBuffer;
	if (FAILED(result = swapChian->GetBuffer(0, IID_PPV_ARGS(backBuffer.GetAddressOf())))) {
		return result;
	}

	if (FAILED(result = device->CreateRenderTargetView(backBuffer.Get(), nullptr, renderTargetView.GetAddressOf()))) {
		return result;
	}

	deviceContext->OMSetRenderTargets(1, renderTargetView.GetAddressOf(), nullptr);

	enabled = true;
	thread = std::thread(RenderThread);

	return true;
}

void ReleaseRenderer() {
	enabled = false;
	if (thread.joinable()) {
		thread.join();
	}
	deviceContext = nullptr;
	device = nullptr;
	swapChian = nullptr;
}

ComPtr<ID3D11Device> GetDevice() {
	return device;
}
