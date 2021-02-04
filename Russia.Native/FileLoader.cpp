#include "FileLoader.h"

const std::vector<uint8_t>& FileLoader::Load(LPCTSTR filename) {
    std::vector<uint8_t> result;

    std::ifstream file(filename);

	if (file.bad() || !file.good()) {
		return {};
	}

	file.seekg(0, std::ios::end);
	size_t size = file.tellg();
	file.seekg(0, std::ios::beg);

	result.resize(size);

	file.read((char*)result.data(), size);

	return result;
}
